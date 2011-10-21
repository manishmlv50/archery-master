//-----------------------------------------------------------------
//  Copyright 2010 Brady Wright and Above and Beyond Software
//	All rights reserved
//-----------------------------------------------------------------


using UnityEngine;
using System.Collections;



// Serves as the base for all non-sprite controls.
// The main purpose of having this is so we can deal with
// all control types as a group, such as using a custom
// inspector.
public abstract class ControlBase : MonoBehaviour, IControl, IUIObject
{
	protected ControlBaseMirror mirror;

	//---------------------------------------------------
	// Control property stuff
	//---------------------------------------------------
	/// <summary>
	/// Text to be displayed on the control.
	/// Do not set this directly in-code. Instead, use
	/// the "Text" property or else your changes will
	/// not take effect.
	/// </summary>
	public string text;

	/// <summary>
	/// Reference to optional SpriteText which will display
	/// this item's text. It is STRONGLY recommended that
	/// this mesh exist on a GameObject that is a child of
	/// the list item itself.
	/// </summary>
	public SpriteText spriteText;			// Mesh that will display our text

	/// <summary>
	/// When text is generated by the control at runtime, 
	/// it will, by default, have its offsetZ setting set 
	/// to this value.  NOTE: Negative values will result
	/// in text being in front of the control.  Positive
	/// values will place the text behind the control.
	/// </summary>
	public float textOffsetZ = -0.1f;

	/// <summary>
	/// When true, of a collider is generated for the
	/// control, the associated text is taken into
	/// account when calculating the extents of the
	/// collider.
	/// </summary>
	public bool includeTextInAutoCollider;

	// Default text options, used when creating a new child
	// SpriteText object:
	protected SpriteText.Anchor_Pos defaultTextAnchor = SpriteText.Anchor_Pos.Middle_Center;
	protected SpriteText.Alignment_Type defaultTextAlignment = SpriteText.Alignment_Type.Center;

	// Lets us keep track of whether we've been destroyed
	protected bool deleted = false;


	/// <summary>
	/// Sets the text to be displayed in this control.
	/// </summary>
	public virtual string Text
	{
		get { return text; }

		set
		{
			text = value;

			// See if we need to create a TextMesh and an
			// object to host it:
			if (spriteText == null)
			{
				if (text == "")
					return;

				if (UIManager.instance == null)
				{
					Debug.LogWarning("Warning: No UIManager exists in the scene. A UIManager with a default font is required to automatically add text to a control.");
					return;
				}
				else if (UIManager.instance.defaultFont == null)
				{
					Debug.LogWarning("Warning: No default font defined.  A UIManager object with a default font is required to automatically add text to a control.");
					return;
				}

				// Create a GO to host the TextMesh:
				GameObject go = new GameObject();
				go.layer = gameObject.layer;
				go.transform.parent = transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localRotation = Quaternion.identity;
				go.name = "control_text";

				// Add a mesh renderer:
				MeshRenderer mr = (MeshRenderer)go.AddComponent(typeof(MeshRenderer));
				mr.material = UIManager.instance.defaultFontMaterial;

				// Add the SpriteText component:
				spriteText = (SpriteText)go.AddComponent(typeof(SpriteText));
				spriteText.font = UIManager.instance.defaultFont;

				spriteText.offsetZ = textOffsetZ;

				// Tell the text object we're its parent
				spriteText.Parent = this;

				// Anchor and align centered by default:
				spriteText.anchor = defaultTextAnchor;
				spriteText.alignment = defaultTextAlignment;
				spriteText.pixelPerfect = true;
			}

			spriteText.Text = text;

			// Update the collider if need be:
			if (includeTextInAutoCollider)
				UpdateCollider();
		}
	}

	// Tracks whether we are using a pre-made collider.
	protected bool customCollider;

	/// <summary>
	/// Can hold a reference to any data that the
	/// developer wishes to be associated with
	/// the control.
	/// </summary>
	[HideInInspector]
	public object data;

	/// <summary>
	/// Accessor for the data member to comply
	/// with the IControl interface.
	/// </summary>
	public object Data
	{
		get { return data; }
		set { data = value; }
	}

	public virtual bool IncludeTextInAutoCollider
	{
		get { return includeTextInAutoCollider; }
		set
		{
			includeTextInAutoCollider = value;
			UpdateCollider();
		}
	}

	protected virtual void Awake()
	{
		if (collider != null)
			customCollider = true;
	}

	public virtual void Start()
	{
		if (spriteText != null)
			spriteText.Parent = this;
	}


	// Adds a basic box collider to this control.
	protected virtual void AddCollider()
	{
		// Don't create our own if a custom collider exists
		if (customCollider)
			return;

		gameObject.AddComponent(typeof(BoxCollider));
		UpdateCollider();
	}

	/// <summary>
	/// Updates the collider of the control so that
	/// it encompasses the extents of the control's
	/// content.
	/// NOTE: To include the control's associated
	/// text in the calculation, be sure to check
	/// the includeTextInAutoCollider box.
	/// </summary>
	public virtual void UpdateCollider()
	{
		if (customCollider || !(collider is BoxCollider))
			return;

		BoxCollider bc = (BoxCollider)collider;

		if (includeTextInAutoCollider && spriteText != null)
		{
			Bounds bounds = new Bounds(bc.center, bc.size);

			Matrix4x4 sm = spriteText.transform.localToWorldMatrix;
			Matrix4x4 lm = transform.worldToLocalMatrix;
			Vector3 tl = lm.MultiplyPoint3x4(sm.MultiplyPoint3x4(spriteText.TopLeft)) * 2f;
			Vector3 br = lm.MultiplyPoint3x4(sm.MultiplyPoint3x4(spriteText.BottomRight)) * 2f;
			bounds.Encapsulate(tl);
			bounds.Encapsulate(br);

			bc.size = bounds.extents;
			bc.center = bounds.center * 0.5f;
		}

		bc.isTrigger = true;
	}


	//---------------------------------------------------
	// IUIObject interface stuff
	//---------------------------------------------------
	protected bool m_controlIsEnabled = true;

	/// <summary>
	/// Allows you to get/set whether the control is disabled.
	/// If it is disabled, it will not receive input.
	/// </summary>
	public virtual bool controlIsEnabled
	{
		get { return m_controlIsEnabled; }
		set { m_controlIsEnabled = value; }
	}

	protected IUIContainer container;

	public virtual IUIContainer Container
	{
		get { return container; }
		set
		{
			if (container != null)
			{
				if (spriteText != null)
					container.RemoveChild(spriteText.gameObject);
			}

			if (value != null)
			{
				if (spriteText != null)
					value.AddChild(spriteText.gameObject);
			}

			container = value;
		}
	}

	public bool RequestContainership(IUIContainer cont)
	{
		Transform t = transform.parent;
		Transform c = ((Component)cont).transform;

		while (t != null)
		{
			if (t == c)
			{
				Container = cont;
				return true;
			}
			else if (t.gameObject.GetComponent("IUIContainer") != null)
				return false;

			t = t.parent;
		}

		// Never found *any* containers:
		return false;
	}

	public virtual bool GotFocus() { return false; }

	protected EZInputDelegate inputDelegate;
	protected EZValueChangedDelegate changeDelegate;
	public virtual void SetInputDelegate(EZInputDelegate del)
	{
		inputDelegate = del;
	}
	public virtual void AddInputDelegate(EZInputDelegate del)
	{
		inputDelegate += del;
	}
	public virtual void RemoveInputDelegate(EZInputDelegate del)
	{
		inputDelegate -= del;
	}
	public virtual void SetValueChangedDelegate(EZValueChangedDelegate del)
	{
		changeDelegate = del;
	}
	public virtual void AddValueChangedDelegate(EZValueChangedDelegate del)
	{
		changeDelegate += del;
	}
	public virtual void RemoveValueChangedDelegate(EZValueChangedDelegate del)
	{
		changeDelegate -= del;
	}

	public virtual void OnInput(POINTER_INFO ptr)
	{
		if (Container != null)
		{
			ptr.callerIsControl = true;
			Container.OnInput(ptr);
		}
	}

	public virtual void OnDestroy()
	{
		deleted = true;
	}


	//---------------------------------------------------
	// IControl compliance stuff
	//---------------------------------------------------
	public virtual void Copy(IControl ctl)
	{
		Copy(ctl, ControlCopyFlags.All);
	}

	public virtual void Copy(IControl ctl, ControlCopyFlags flags)
	{
		if (!(ctl is ControlBase))
			return;

		ControlBase c = (ControlBase)ctl;


		// Copy transitions:
		if ((flags & ControlCopyFlags.Transitions) == ControlCopyFlags.Transitions)
		{
			if (c is UIStateToggleBtn3D)
			{
				if (c.Transitions != null)
				{
					((UIStateToggleBtn3D)this).transitions = new EZTransitionList[c.Transitions.Length];
					for (int i = 0; i < Transitions.Length; ++i)
						c.Transitions[i].CopyToNew(Transitions[i], true);
				}
			}
			else
			{
				if (Transitions != null && c.Transitions != null)
					for (int i = 0; i < Transitions.Length && i < c.Transitions.Length; ++i)
						c.Transitions[i].CopyTo(Transitions[i], true);
			}
		}


		if ((flags & ControlCopyFlags.Text) == ControlCopyFlags.Text)
		{
			// See if we want to clone the other
			// control's text mesh:
			if (spriteText == null && c.spriteText != null)
			{
				GameObject newText = (GameObject)Instantiate(c.spriteText.gameObject);
				newText.transform.parent = transform;
				newText.transform.localPosition = c.spriteText.transform.localPosition;
				newText.transform.localScale = c.spriteText.transform.localScale;
				newText.transform.localRotation = c.spriteText.transform.localRotation;
			}

			Text = c.Text;
		}

		if ((flags & ControlCopyFlags.Appearance) == ControlCopyFlags.Appearance)
		{
			// See if we can copy the other control's collider's settings:
			if (collider.GetType() == c.collider.GetType())
			{
				if (collider is BoxCollider)
				{
					BoxCollider bc1 = (BoxCollider)collider;
					BoxCollider bc2 = (BoxCollider)c.collider;
					bc1.center = bc2.center;
					bc1.size = bc2.size;
				}
				else if (collider is SphereCollider)
				{
					SphereCollider sc1 = (SphereCollider)collider;
					SphereCollider sc2 = (SphereCollider)c.collider;
					sc1.center = sc2.center;
					sc1.radius = sc2.radius;
				}
				else if (collider is CapsuleCollider)
				{
					CapsuleCollider cc1 = (CapsuleCollider)collider;
					CapsuleCollider cc2 = (CapsuleCollider)c.collider;
					cc1.center = cc2.center;
					cc1.radius = cc2.radius;
					cc1.height = cc2.height;
					cc1.direction = cc2.direction;
				}
				else if (collider is MeshCollider)
				{
					MeshCollider mc1 = (MeshCollider)collider;
					MeshCollider mc2 = (MeshCollider)c.collider;
					mc1.smoothSphereCollisions = mc2.smoothSphereCollisions;
					mc1.convex = mc2.convex;
					mc1.sharedMesh = mc2.sharedMesh;
				}

				collider.isTrigger = c.collider.isTrigger;
			}
		}

		if ((flags & ControlCopyFlags.Invocation) == ControlCopyFlags.Invocation)
		{
			changeDelegate = c.changeDelegate;
			inputDelegate = c.inputDelegate;
		}

		if ((flags & ControlCopyFlags.State) == ControlCopyFlags.State)
		{
			Container = c.Container;

			if (Application.isPlaying)
				controlIsEnabled = c.controlIsEnabled;
		}
	}


	//---------------------------------------------------
	// Inspector/Editor stuff
	//---------------------------------------------------
	public abstract string[] States
	{
		get;
	}


	// Draws the UI for the control's
	// properties before state selection.
	// Accepts the currently-selected state
	// index.
	// The height of the content drawn is
	// returned so that other UI elements 
	// can be adjusted accordingly:
	public virtual int DrawPreStateSelectGUI(int selState, bool inspector) { return 0; }

	// Draws the UI for the control's
	// properties after state selection.
	// Accepts the currently-selected state
	// index.
	// The height of the content drawn is
	// returned so that other UI elements 
	// can be adjusted accordingly:
	public virtual int DrawPostStateSelectGUI(int selState) { return 0; }

	// Draws the UI for the control's properties
	// just before the transition UI stuff is drawn.
	public virtual void DrawPreTransitionUI(int selState, IGUIScriptSelector gui) { }

	// Returns an array of strings which are the
	// names of the states/elements supported by
	// the control.
	public virtual string[] EnumStateElements()
	{
		return States;
	}

	// So that we can access each control type's different
	// transition arrays in a generic manner:
	public abstract EZTransitionList GetTransitions(int index);

	public abstract EZTransitionList[] Transitions
	{
		get;
		set;
	}


	//---------------------------------------------------
	// Edit-time updating stuff
	//---------------------------------------------------

	// Ensures that the control is updated in the scene view
	// while editing:
	public virtual void OnDrawGizmos()
	{
		// Only run if we're not playing:
		if (Application.isPlaying)
			return;

		if (mirror == null)
		{
			mirror = new ControlBaseMirror();
			mirror.Mirror(this);
		}

		mirror.Validate(this);

		// Compare our mirrored settings to the current settings
		// to see if something was changed:
		if (mirror.DidChange(this))
		{
			mirror.Mirror(this);	// Update the mirror
		}
	}
}


// Mirrors the editable settings of a control that affect
// how the control is drawn in the scene view
public class ControlBaseMirror
{
	string text;
	float textOffsetZ;

	// Mirrors the specified control's settings
	public virtual void Mirror(ControlBase c)
	{
		text = c.text;
		textOffsetZ = c.textOffsetZ;
	}


	// Returns true if any of the settings do not match:
	public virtual bool DidChange(ControlBase c)
	{
		if (text != c.text)
		{
			c.Text = c.text;
			return true;
		}

		if (textOffsetZ != c.textOffsetZ)
		{
			if (c.spriteText != null)
				c.spriteText.offsetZ = textOffsetZ;
			return true;
		}

		return false;
	}

	public virtual void Validate(ControlBase c)
	{

	}
}