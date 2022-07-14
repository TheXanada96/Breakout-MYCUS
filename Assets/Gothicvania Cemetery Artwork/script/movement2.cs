// esempi in C# Unity
using System.Collections; // richiama un pacchetto contenente interfacce e classi che definiscono raccolte di comandi.
using System.Collections.Generic;
using UnityEngine; // richiama un pacchetto contenente interfacce e classi default di Unity

// 
public class pene : MonoBehaviour // classe base che fa accedere a una serie di funzioni predefinite
{
    string ciao = "ciao mondo"; // variabile stringa 
    int contenitore = 5; // variabile intera con valore 5
    public Vector2 speed = new Vector2(10, 10); // variabile pubblica (modificabile nell'editor) responsabile per il movimento dell'oggetto


    void Start() // inizializza un comando appena parte che non resistuisce alcun valore(per il void)
    {
        contenitore = barattolo(contenitore);
        Debug.Log(contenitore);
        Debug.Log(ciao);
    }

    void Update() // inizializza un comando ogni frame che non resistuisce alcun valore(per il void)
    {
        float inputX = Input.GetAxis("Horizontal"); // variabile in decimale, che restituisce il valore dell'asse virtuale(dato in Unity) orizzontale
        float inputY = Input.GetAxis("Vertical"); // variabile in decimale, che restituisce il valore dell'asse virtuale(dato in Unity) verticale

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0); // il Vector3 si ottiene moltiplicando speed x/y con input x/y la z vale 0

        movement *= Time.deltaTime; // quantita di secondi impiegati dal motore per elaborare il frame precedente

        transform.Translate(movement); //Sposta la trasformazione nella direzione di traslazione
    }

private int barattolo(int numero) // funzione barattolo che richiede un numero intero "numero"
    {
        int risultato; // variabile vuota
        risultato = numero * 3; //il risultatato si ottiene moltiplicando numero * 3
        return risultato; // ritorna il valore di risultato
        }
}
