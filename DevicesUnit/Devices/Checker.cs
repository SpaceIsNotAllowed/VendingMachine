using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesUnit
{
    public interface IChecker
    {
        bool Check(Banknote banknote); // запускает проверку
        void Start(); // инициализирует проверку
        void Update(); // обновляет состояние проверки
        void Finish(); // завершает проверку
        int GetResult(); // возвращает результат проверки
    }

    public class Checker: IChecker
    {
       private int  _result;         // результат проверки
       private Banknote _banknote;   // переданная купюра
       private bool _started;        // проводится ли проверка в данный момент
       private int  _time;           // время от начала проверки

       public Checker()
       {
           _result = 0;
           _started = false;
           _time = 0;
       }

       private int Check() // выполняет проверку подлинности купюры и сохраняет результат проверки
       {
           if (_time > 20)
           {
               Finish();

               _result = _banknote.Value;

               return _result;
           }
           else return -1;
       }
       
       public bool Check(Banknote banknote) // запускает проверку
       {
           if (!_started)
           {
               this._banknote = banknote;
               Start();
               return true; // купюра принята на проверку
           }
           else
               return false; // устройство занято
       }

       public void Start() // инициализирует проверку
       {
           _time = 0;
           _started = true;
       }

       public void Update() // обновляет состояние проверки
       {
           if (_started)
           {
               _time++;
               Check();
           }
       }

       public void Finish() // завершает проверку
       {
           _started = false;
       }

       public int GetResult() // возвращает результат проверки
       {
           if (_started) return -1;

           int banknotePrice = _result;
           _result = 0;
           return banknotePrice;
       }
   }
}
