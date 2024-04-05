using System.Reflection.Metadata.Ecma335;

public class RationalNumber
{
    private int _nominator;
    private int _denominator;
    public int Nominator
    {
        get
        {
            return this._nominator;
        }
    }

    public int Denominator
    {
        get
        {
            return this._denominator;
        }
    }

    public RationalNumber(int a, int b)
    {
        this._nominator = a;
       
        this._denominator = Math.Abs(b);
        if ( b < 0)
            this._nominator *= -1;
        if (this._denominator == 0)
        {
            throw new DivideByZeroException();
        }
    }

    private void Simplize() {
        if (this._nominator == 0 || this._denominator == 0){
            return;
        }
        int nod = MyMath.NOD(this._nominator, this._denominator);
        this._nominator /= nod;
        this._denominator /= nod;
    }

    public static RationalNumber operator + (RationalNumber a, RationalNumber b) {
        return new RationalNumber(a._nominator * b._denominator + b._nominator * a._denominator, a._denominator*b._denominator);
    }

    public static RationalNumber operator - (RationalNumber a){
        return new RationalNumber(-a._nominator, a._denominator);
    }

    public static RationalNumber operator - (RationalNumber a, RationalNumber b){
        return a + (-b);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        a.Simplize();
        b.Simplize();
        return a._nominator == b._nominator && a._denominator == b._denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return ! (a == b);
    }

    public static bool operator > (RationalNumber a, RationalNumber b)
    {
        int nok = MyMath.NOK(a._denominator, b._denominator);
        return a._nominator * (nok / b._denominator) > b._nominator * (nok / a._denominator);
    }

    public static bool operator < (RationalNumber a, RationalNumber b)
    {
        int nok = MyMath.NOK(a._denominator, b._denominator);
        return a._nominator * (nok / b._denominator) < b._nominator * (nok / a._denominator);
    }

    public override string ToString()
    {
        this.Simplize();
        if(this._nominator == 0) {
            return "0";
        }
        if (this._denominator == 0) {
            return "Uncorrect number"; 
        }
        if (this._denominator == 1){
            return $"{this._nominator}";
        }
        return $"{this._nominator}/{this._denominator}";
    }
}