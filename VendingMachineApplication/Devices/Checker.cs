﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public class Checker
   {
       private int  result;         // результат проверки
       private Banknote banknote;   // тип переданной купюры
       private bool started;        // проводится ли проверка в данный момент
       private int  time;           // время от начала проверки

       public Checker()
       {
           result = -1;
           started = false;
           time = 0;
       }

       internal Acceptor Acceptor
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

       private int Check() // выполняет проверку подлинности купюры и сохраняет результат проверки
       {
           if (time > 20)
           {
               Finish();

               result = banknote.Value;

               return result;
           }
           else return -1;
       }
       
       public int Check(Banknote banknote) // запускает проверку
       {
           if (!started)
           {
               this.banknote = banknote;
               Start();
           }
           return -1;

       }

       public void Start() // инициализирует проверку
       {
           time = 0;
           started = true;
       }

       public void Update() // обновляет состояние проверки
       {
           if (started)
           {
               time++;
               Check();
           }
       }

       public void Finish() // завершает проверку
       {
           started = false;
       }

       public int GetResult() // возвращает результат проверки
       {
           if (started || result == -1) return -1;

           int tmp = result;
           result = -1;
           return tmp;
       }
   }
}
