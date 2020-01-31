using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetReference : MonoBehaviour
{
    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;
    public Sprite E;
    public Sprite F;
    public Sprite G;
    public Sprite H;
    public Sprite I;
    public Sprite J;
    public Sprite K;
    public Sprite L;
    public Sprite M;
    public Sprite N;
    public Sprite O;
    public Sprite P;
    public Sprite Q;
    public Sprite R;
    public Sprite S;
    public Sprite T;
    public Sprite U;
    public Sprite V;
    public Sprite W;
    public Sprite X;
    public Sprite Y;
    public Sprite Z;
    public Sprite No0;
    public Sprite No1;
    public Sprite No2;
    public Sprite No3;
    public Sprite No4;
    public Sprite No5;
    public Sprite No6;
    public Sprite No7;
    public Sprite No8;
    public Sprite No9;
    public Sprite Exclamation;
    public Sprite Question;
    public Sprite Hyphen;
    public Sprite FullStop;
    public Sprite Comma;
    public Sprite LeftBracket;
    public Sprite RigthBracket;
    public Sprite Slash;
    public Sprite Ampersand;
    public Sprite Empty;

    public Sprite characterToClay(char cha)
    {
        cha = char.ToUpper(cha);
        Sprite s = Empty;

        if (cha == 'A')
        {
            s = A;
        }
        else if (cha == 'B')
        {
            s = B;
        }
        else if (cha == 'C')
        {
            s = C;
        }
        else if (cha == 'D')
        {
            s = D;
        }
        else if (cha == 'E')
        {
            s = E;
        }
        else if (cha == 'F')
        {
            s = F;
        }
        else if (cha == 'G')
        {
            s = G;
        }
        else if (cha == 'H')
        {
            s = H;
        }
        else if (cha == 'I')
        {
            s = I;
        }
        else if (cha == 'J')
        {
            s = J;
        }
        else if (cha == 'K')
        {
            s = K;
        }
        else if (cha == 'L')
        {
            s = L;
        }
        else if (cha == 'M')
        {
            s = M;
        }
        else if (cha == 'N')
        {
            s = N;
        }
        else if (cha == 'O')
        {
            s = O;
        }
        else if (cha == 'P')
        {
            s = P;
        }
        else if (cha == 'Q')
        {
            s = Q;
        }
        else if (cha == 'R')
        {
            s = R;
        }
        else if (cha == 'S')
        {
            s = S;
        }
        else if (cha == 'T')
        {
            s = T;
        }
        else if (cha == 'U')
        {
            s = U;
        }
        else if (cha == 'V')
        {
            s = V;
        }
        else if (cha == 'W')
        {
            s = W;
        }
        else if (cha == 'X')
        {
            s = X;
        }
        else if (cha == 'Y')
        {
            s = Y;
        }
        else if (cha == 'Z')
        {
            s = Z;
        }
        else if (cha == '0')
        {
            s = No0;
        }
        else if (cha == '1')
        {
            s = No1;
        }
        else if (cha == '2')
        {
            s = No2;
        }
        else if (cha == '3')
        {
            s = No3;
        }
        else if (cha == '4')
        {
            s = No4;
        }
        else if (cha == '5')
        {
            s = No5;
        }
        else if (cha == '6')
        {
            s = No6;
        }
        else if (cha == '7')
        {
            s = No7;
        }
        else if (cha == '8')
        {
            s = No8;
        }
        else if (cha == '9')
        {
            s = No9;
        }
        else if (cha == '!')
        {
            s = Exclamation;
        }
        else if (cha == '?')
        {
            s = Question;
        }
        else if (cha == '&')
        {
            s = Ampersand;
        }
        else if (cha == '.')
        {
            s = FullStop;
        }
        else if (cha == ',')
        {
            s = Comma;
        }
        else if (cha == '-')
        {
            s = Hyphen;
        }
        else if (cha == '(')
        {
            s = LeftBracket;
        }
        else if (cha == ')')
        {
            s = RigthBracket;
        }
        else if (cha == '/')
        {
            s = Slash;
        }

        return s;
    }
}