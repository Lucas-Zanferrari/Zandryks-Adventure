using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextController : MonoBehaviour {

    private string[] introTextChunks = new string[6]
    {"A história se passa em um planeta Terra seguidamente pós-apocalíptico, em que as noções tradicionais de contagem da passagem do tempo, de convivência entre indivíduos e das matérias primas que constituem o comportamento social foram alteradas, reformadas e modificadas completamente incontáveis vezes.",

    "Fosse um produto do destino ou da manipulação de algum ditador tirano, fosse em decorrência de fenômenos naturais ou guerras sangrentas, a história da deste pequeno planeta localizado na antigamente chamada Via-Láctea por uma de suas espécies, os humanos, fora escrita, apagada e rescrita tantas vezes que seus habitantes atuais, mesmo que quisessem, não conseguiriam estudar e catalogar todos os mistérios que existiam à serem explorados naquele lugar.",

    "Porém nas últimas décadas, em um local distante e rudimentar ao norte, uma pseudo-civilização se formava. Esta pequena e frágil estrutura social era composta de indivíduos de diversas espécies. Fossem humanos ou animais adaptados, todos se encontravam neste ponto singular do planeta, e dotados do poder de uma língua em comum desenvolvida por seus antepassados, conquistaram a capacidade de se organizar, construir abrigos, plantar alimento e planejar o crescimento em conjunto.",

    "Esta sociedade, embora simplória e pouco avançada, era modelo de igualdade entre seus indivíduos, de modo que seres de diferentes espécies moravam juntos, nutriam relações afetivas, faziam comércio, adoravam as mesmas divindades, executavam as mesmas tarefas em benefício do grupo e afora conflitos discretos, caminhavam sempre em comunhão.",

    "Apesar de todos os esforços, o clima era implacável, a os recursos eram escassos e o tempo era curto. Em meio a uma reunião de planejamento, famílias da sociedade se dispuseram a enfrentar o desconhecido externo para encontrar recursos. O lobo Zanfryd ouviu seu criador, o bondoso guerreiro-humano Donkard, declarar que levaria sua família em uma das missões de reconhecimento e embora amedrontado, confortou-se imaginando que esta seria apenas mais uma aventura com sua amada família.",

    "Mas Zanfryd estava enganado. Após o terceiro dia e a terceira noite de exploração, ele desperta longe de seus parentes em um local desconhecido. A floresta parece pacífica e exala uma aura curiosa, mas Zanfryd não se deixa enganar e, embora jovem e inexperiente, sabe que precisará se valer de seu curto treinamento, sua vontade de rever seus entes queridos e, principalmente, de seus instintos mais primais para reencontrar seus familiares o mais rápido possível, antes que os perca de sua vida definitivamente."};

    private MalbersAnimations.MFreeLookCamera freeLookCameraScript;
    private TimerManager timerManager;
    private GameObject messageComponent;
    private Text messageText;
    private MessageController messageController;
    private GameObject instructionText;
    private GameObject lightsContainer;
    private GameObject directionalLight0;
    private GameObject directionalLight1;
    private GameObject relative;
    private int i = 0;

    // Use this for initialization
    void Start() {
        lightsContainer = GameObject.Find("Lighting").gameObject;
        directionalLight0 = lightsContainer.transform.Find("Directional Light").gameObject;
        directionalLight1 = lightsContainer.transform.Find("Directional Light (1)").gameObject;

        relative = GameObject.Find("Relative").gameObject.transform.Find("Mobryd").gameObject;
        freeLookCameraScript = GetComponent<MalbersAnimations.MFreeLookCamera>();

        messageComponent = GameObject.Find("Message").gameObject;
        messageController = messageComponent.GetComponent<MessageController>();
        timerManager = GameObject.Find("Timer").gameObject.GetComponent<TimerManager>();

        instructionText = GameObject.Find("Instructions").gameObject;

        freeLookCameraScript.enabled = false;
        timerManager.enabled = false;

        messageText = messageComponent.GetComponent<Text>();
        messageText.text = introTextChunks[i];
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetButtonDown("EnterJoy")) {
			if (i >= introTextChunks.Length-1) {
				freeLookCameraScript.enabled = true;
				timerManager.enabled = true;
				messageController.enabled = true;
				directionalLight0.SetActive(true);
				directionalLight1.SetActive(true);
				relative.SetActive(true);
				instructionText.SetActive(false);
			}
			else {
				messageText.text = introTextChunks[++i];
			}
		}
	}
}
