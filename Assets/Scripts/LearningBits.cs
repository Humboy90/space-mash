using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningBits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //0001
        //0010
        //0011
        //0100
        //0101
        //0110
        //0111
        //1000 8
        //1001
        //1010
        //1011
        //1100 12
        //1101
        //1110
        //1111 15


        
        //1100
        //0001
        //1101
        //if (true || false)
        //{
        //    Debug.Log("true");
        //}
        //else
        //{
        //    Debug.Log("false");
        //}
        int num = 3<<2;
        num = num | 1;
        Debug.Log(num);
        int bitfield = 0;
        //00000000000000000000000000000000
        bitfield = bitfield | (5 << 4);
        //00000000000000000000000001010000
        bitfield = bitfield | 3;
        bitfield = bitfield | (12 << 16);
        //00000000000000000000000001010011
        //00000000000000000000000011110000
        //00000000000000000000000001010000
        int value0 = (bitfield & (15<<0))>>0;
        Debug.Log(bitfield);
        int value1 = (bitfield & (15 << 4))>>4;
        int value4 = (bitfield & (15 << 16)) >> 16;
        Debug.Log(value0);
        Debug.Log(value1);
        Debug.Log(value4);
        int test = CompressNumbers(7, 21, 14, 25);
        Debug.Log(test);
        GetNumbers(test, out byte num0, out byte num1, out byte num2, out byte num3);
        Debug.Log(num0);
        Debug.Log(num1);
        Debug.Log(num2);
        Debug.Log(num3);
    }


    int CompressNumbers(byte a, byte b, byte c,byte d)
    {
        return a | (b << 8) | (c << 16) | (d << 24);
    }

    void GetNumbers(int source, out byte a, out byte b, out byte c,out byte d)
    {
        a = (byte)((source >> 0) & 255);
        b = (byte)((source >> 8) & 255);
        c = (byte)((source >> 16) & 255);
        d = (byte)((source >> 24) & 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
