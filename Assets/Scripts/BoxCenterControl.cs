using UnityEngine;
using System.Collections;
//github branch test
public class BoxCenterControl : MonoBehaviour 
{
    public Color32[] colorStorage;
    public SpriteRenderer[] sp;
    // Use this for initialization
    void Start()
    {
        SetSpritesColor(sp, colorStorage[2], colorStorage[3]);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    Color32[] CreateGradient(Color32 startColor, Color32 endColor, int colorBoxNum)
    {
        Color32[] colorcase = new Color32[colorBoxNum];
        float rInterpolation = (endColor.r - startColor.r) / (colorBoxNum - 1);
        float gInterpolation = (endColor.g - startColor.g) / (colorBoxNum - 1);
        float bInterpolation = (endColor.b - startColor.b) / (colorBoxNum - 1);
        for (int n = 0; n < colorBoxNum; n++)
        {
            colorcase[n] = new Color32((byte)(startColor.r + rInterpolation * n), (byte)(startColor.g + gInterpolation * n), (byte)(startColor.b + bInterpolation * n), 255);
        }

        return colorcase;
    }
    void SetSpritesColor(SpriteRenderer[] sprite, Color32 startColor, Color32 endColor)
    {
        Color32[] colors = CreateGradient(startColor, endColor, sprite.Length);
        for (int n = 0; n < sprite.Length; n++)
        {
            sprite[n].color = colors[n];
        }
        print("bool" + CheckColorSuit(colors));
    }
    bool CheckColorSuit(Color32[] colors)
    {
        float[] r = new float[colors.Length];
        float[] g = new float[colors.Length];
        float[] b = new float[colors.Length];
        for (int n = 0; n < colors.Length; n++)
        {
            r[n] = colors[n].r;
            g[n] = colors[n].g;
            b[n] = colors[n].b;
            //print(r[n] + "  " + g[n] + "  " + b[n]);
        }
        if (CheckValueSuit(r) && CheckValueSuit(g) && CheckValueSuit(b))
            return true;
        else
            return false;
    }
    bool CheckValueSuit(float[] num)
    {
        float sign = Mathf.Sign(num[0] - num[1]);
        //print((num[0] == num[1]) + " offset!!! "); 
        //print("sign is" + sign);
        for (int n = 1; n < num.Length - 1; n++)
        {
            if (Mathf.Sign(num[n] - num[n + 1]) == sign&&num[n]!=num[n+1])
                continue;
            else return false;
        }
        return true;
    }
}
