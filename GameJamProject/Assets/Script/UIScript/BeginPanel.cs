using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel
{

    public Button Begin;
    public Button Exit;
    
    public override void Init()
    {
        DontDestroyOnLoad(this.gameObject);
        
        Begin.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);


            UIManager.Instance.HidePanel<BeginPanel>();
        });

        Exit.onClick.AddListener(() =>
        {


            Application.Quit();
        });
    }
}
