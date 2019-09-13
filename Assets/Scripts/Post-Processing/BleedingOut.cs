using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BleedingOut : MonoBehaviour
{
    public float maxHealth = 100;
    public float curHealth;
    public float healthToStartEffect = 50;
    public float intensityChange = .1f;
    public float maxIntensity = .5f;
    public float minIntensity = -.1f;
    public ColorParameter vigColor;

    private PostProcessVolume m_Volume;
    private Vignette m_Vignette;
    private float curIntensity = 0;
    private bool posIntensity = true;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        if(healthToStartEffect > maxHealth)
        {
            healthToStartEffect = maxHealth;
        }

        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);
        m_Vignette.color.Override(vigColor);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 50f, m_Vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= healthToStartEffect)
        {
            if (posIntensity == true)
            {
                curIntensity += intensityChange;
                if (curIntensity >= maxIntensity)
                {
                    posIntensity = false;
                }
            }
            else if (posIntensity == false)
            {
                curIntensity -= intensityChange;
                if (curIntensity <= minIntensity)
                {
                    posIntensity = true;
                }
            }

            m_Vignette.intensity.value = Mathf.Sin(curIntensity);
        }
        else
        {
            if(curIntensity > 0)
            {
                curIntensity -= intensityChange;
            }
            else if(curIntensity < 0)
            {
                curIntensity += intensityChange;
            }

            m_Vignette.intensity.value = Mathf.Sin(curIntensity);
        }
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
