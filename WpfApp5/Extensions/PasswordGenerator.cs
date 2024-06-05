using System.Windows.Media;

namespace WpfApp5.Extensions;

public class PasswordGenerator
{
    private IList<char> _chars = new List<char>()
    {
        'q', 'w', 'e', 'r', 't', 't', 'y'
    };

    private IList<int> _ints = new List<int>()
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9,

    };

    protected  IList<char>  _chars1 = new List<char>()
    {
        '!', '@', '#', '$', '%', '^', '&'
    };
    
    public virtual string GeneratePassword(DifPass difficult, int leinght)
    { 
        
        switch (difficult)
        {
            case DifPass.Easy:
                return GeneratorEasy(leinght);
            case DifPass.Medium:
                return GeneratoreMiddle(leinght);
            case DifPass.Hard:
                return GeneratoreHard(leinght);
            default:
                throw new ArgumentOutOfRangeException(nameof(difficult), difficult, null);
        }
        return string.Empty;
    }

    protected string GeneratorEasy(int leinght)
    {
        string pwd = string.Empty;
        for (int i = 0; i < leinght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
        }

        return pwd;
    }

    private string GeneratoreMiddle(int leinght)
    {
        string pwd = string.Empty;
        for (int i = 0; i < leinght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
            pwd += _chars[new Random().Next(0, _chars.Count)];
        }

        pwd = Shuffle(pwd);

        return pwd.Substring(leinght);
    }

    private string GeneratoreHard(int leinght)
    {
        string pwd = string.Empty;
        for (int  i = 0; i < leinght; i++)
        {
            pwd += _ints[new Random().Next(0, _ints.Count)];
            pwd += _chars[new Random().Next(0, _chars.Count)];
            pwd += _chars1[new Random().Next(0, _chars1.Count)];
        }

        pwd = Shuffle(pwd);

        var pwdnew = string.Empty;
        for (int i = 0; i < leinght; i++)
        {
            pwdnew += pwd[i];
        }
        return pwdnew;
    }

    public string Shuffle(string str)
    {
        char[] array = str.ToCharArray();
        Random rng = new Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (array[k], array[n]) = (array[n], array[k]);
        }

        return new string(array);
    }
}