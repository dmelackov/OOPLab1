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
        this.Simplize();
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
        return new RationalNumber(a.Nominator * b.Denominator + b.Nominator * a.Denominator, a.Denominator*b.Denominator);
    }

    public static RationalNumber operator - (RationalNumber a){
        return new RationalNumber(-a.Nominator, a.Denominator);
    }

    public static RationalNumber operator - (RationalNumber a, RationalNumber b){
        return a + (-b);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        return a.Nominator == b.Nominator && a.Denominator == b.Denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return ! (a == b);
    }

    public static bool operator > (RationalNumber a, RationalNumber b)
    {
        return a.Nominator *  b.Denominator > b.Nominator * a.Denominator;
    }

    public static bool operator < (RationalNumber a, RationalNumber b)
    {
        return a.Nominator * b.Denominator < b.Nominator * a.Denominator;
    }

    public override string ToString()
    {
        if(this.Nominator == 0) {
            return "0";
        }
        if (this.Denominator == 0) {
            return "Uncorrect number"; 
        }
        if (this.Denominator == 1){
            return $"{this.Nominator}";
        }
        return $"{this.Nominator}/{this.Denominator}";
    }
}