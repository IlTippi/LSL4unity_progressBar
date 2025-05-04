using UnityEngine;
using LSL;
using System;

/// <summary>
/// Questo script riceve dati EEG da uno stream LSL e li stampa in console.
/// Assicurati di avere un flusso LSL attivo e liblsl-CSharp importato.
/// </summary>
public class LSLReceiver : MonoBehaviour
{
    private StreamInlet inlet;
    private float[] sample;
    private double lastTimestamp;

    void Start()
    {
        try
        {
            // Cerca uno stream con tipo EEG (puoi cambiarlo in base al tuo dispositivo, es. "Unicorn")
            var results = LSL.LSL.resolve_stream("type", "EEG", 1, 5.0);

            if (results.Length > 0)
            {
                inlet = new StreamInlet(results[0]);
                int channelCount = inlet.info().channel_count();
                sample = new float[channelCount];

                Debug.Log($"Stream trovato con {channelCount} canali.");
            }
            else
            {
                Debug.LogWarning("⚠️ Nessuno stream LSL trovato con tipo 'EEG'.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Errore inizializzazione LSL: " + ex.Message);
        }
    }

    void Update()
    {
        if (inlet != null)
        {
            double timestamp = inlet.pull_sample(sample, 0.0f); // 0 = non bloccare

            if (timestamp > 0.0)
            {
                lastTimestamp = timestamp;
                string formatted = string.Join(", ", sample);
                Debug.Log($"t={timestamp:F3}  |  Valori: {formatted}");
            }
        }
    }
}
