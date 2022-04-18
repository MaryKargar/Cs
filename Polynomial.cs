using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polynom
{
    class Polynomial
    {
        private static Term[] termArray;
        private static int free = 0;
        private int first;
        private int last;
        private static int maxterm;
        public static void start_static(int m)
        {
            maxterm = m;
            termArray = new Term[m];
            for (int i = 0; i < m; i++)
            {
                termArray[i] = new Term();
            }
        }
        public Term[] TermArray
        {
            get
            {
                return termArray;
            }
            set
            {
                termArray = value;
            }
        }
        public int Free
        {
            get
            {
                return free;
            }
            set
            {
                free = value;
            }
        }
        public int First
        {
            get
            {
                return first;
            }
            set
            {
                first = value;
            }
        }
        public int Last
        {
            get
            {
                return last;
            }
            set
            {
                last = value;
            }
        }
        public float get_coef(int t)
        {
            return termArray[first + t].Coef;
        }
        public int get_exp(int t)
        {
            return termArray[first + t].Exp;
        }
        public void set_coef(int t, float c)
        {
            termArray[first + t].Coef = c;
        }
        public void set_exp(int t, int e)
        {
            termArray[first + t].Exp = e;
        }
        public Polynomial(int t)
        {
            first = free;
            free = free + t;
            last = free - 1;
        }
        public Polynomial()
        {
            first = free;
            last = 0;
        }
        public static bool have_space()
        {
            if (free >= maxterm) return false;                
            else return true;
        }
        public void new_term(float c, int e)
        {
                termArray[free].Coef = c;
                termArray[free].Exp = e;
                free++;
                last = free - 1;
        }
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int p1counter = p1.first;
            int p2counter = p2.first;
            float sum = 0;
            Polynomial result = new Polynomial();
            while (p1counter <= p1.last && p2counter <= p2.last)
            {
                if (termArray[p1counter].Exp == termArray[p2counter].Exp)
                {
                    sum = termArray[p1counter].Coef + termArray[p2counter].Coef;
                    if (sum != 0)
                    {
                        result.new_term(sum, termArray[p1counter].Exp);
                        p1counter++;
                        p2counter++;
                    }
                }
                else if (termArray[p1counter].Exp < termArray[p2counter].Exp)
                {
                    result.new_term(termArray[p2counter].Coef, termArray[p2counter].Exp);
                    p2counter++;
                }
                else
                {
                    result.new_term(termArray[p1counter].Coef, termArray[p1counter].Exp);
                    p1counter++;
                }
            }
            while (p1counter <= p1.last && p1.TermArray[p1counter].Coef != 0)
            {
                result.new_term(termArray[p1counter].Coef, termArray[p1counter].Exp);
                p1counter++;
            }
            while (p2counter <= p2.last && p2.TermArray[p2counter].Coef != 0)
            {
                result.new_term(termArray[p2counter].Coef, termArray[p2counter].Exp);
                p2counter++;
            }
            return result;
        }
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {

            Polynomial result = new Polynomial();
            result.first = free;
            result.last = free + p1.last;
            free = result.last + 1;
            Polynomial temp;
            for (int i = p2.first; i <= p2.last; i++)
            {
                temp = new Polynomial();
                for (int j = p1.first; j <= p1.last; j++)
                    temp.new_term((p2.TermArray[i].Coef * p1.TermArray[j].Coef), (p2.TermArray[i].Exp + p1.TermArray[j].Exp));
                result += temp;
            }
            return result;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = first; i <= last; i++)
            {
                if (termArray[i].Exp == 1)
                    result += termArray[i].Coef + "x";
                else if (termArray[i].Exp == 0)
                    result += termArray[i].Coef;
                else
                    result += termArray[i].Coef + "x^" + termArray[i].Exp;
                if (i < last)
                    result += "+";
            }
            return result;
        }
    }
}
