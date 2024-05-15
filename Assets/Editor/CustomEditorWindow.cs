using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/CustomEditorWindow")]
    public static void ShowExample()
    {
        CustomEditorWindow wnd = GetWindow<CustomEditorWindow>();
        wnd.titleContent = new GUIContent("CustomEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElements following a tree hierarchy.
        //Label label = new Label("These controls were created using C# code.");
        //root.Add(label);

        //Toggle toggle = new Toggle();
        //toggle.name = "toggle3";
        //toggle.label = "Number?";
        //root.Add(toggle);

        Button button = new Button();
        button.name = "Make Buttons";
        button.text = "Make Buttons";
        root.Add(button);

        

        //Call the event handler
        SetupButtonHandler();

    }

    //Functions as the event handlers for your button click and number counts 
    private void SetupButtonHandler()
    {
        VisualElement root = rootVisualElement;

        var buttons = root.Query<Button>();
        buttons.ForEach(RegisterHandler);
    }

    private void RegisterHandler(Button button)
    {
        button.RegisterCallback<ClickEvent>(MakeButtons);
    }


    private void MakeButtons(ClickEvent evt)
    {
        CallEditor.Instance.CreateButtons();
    }
}