using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    public interface IConnect
    {
         void OpenDB(string p);
         void  BasicQuery(string p, bool r);
         void createDB(string name);
         void InsertInto(string table);
         void closeDB();
    }
    public interface INavigation
    {
        void PrintTopics(int X, int Y);
        void Row(object Row, object Topics);
        object View(object Row, object theme);
    }
    public interface IResult
    {
        void GetSetting(int ret, int level, int might);
        object Row();
        void Print(object Row);
        string LoadCT(string KeyUser);
        void ExportCT(string NewCT);
        void StartTimer();


    }
    public interface ITeacher
    {

        void PrintTopics(string LoadCT);
        void FormGROUP(); void Stat(object group);
    }
    public interface IAutor
    {
        void AddNew(string add);
    }
    public interface IKey
    {
        string LoadCT(string KeyUser);
        void ExportCT(string NewCT);
    }
    public interface IExam
    {
        void LoadDB();
        void View(object Row, object theme);
void DropTimer();
    }

    class learner : IResult
    {
        int ID;
        public void loadCT() { }
        public void exportCT() { }
        public void startTimer(DateTime Time) { }
        public void GetSetting(int ret, int level, int might) { }
        public object Row() { return null; }
        public void Print(object Row) { }
        public string LoadCT(string KeyUser) { string a; a = ""; return a; }
        public void ExportCT(string NewCT) { }
        public void StartTimer() { }
    }
    class connect : IConnect
    {
        string db;
        bool yes;
        string tablename;
        
        Object[] table = new Object [] {};     
      
        public void TAkevalue() { }
        public void OpenDB(string p) { }
        public void BasicQuery(string p, bool r) { }
        public void createDB(string name) { }
        public void InsertInto(string table) { }
        public void closeDB() { }
    }
    class auten : connect
    {
        learner yes;
        public void OpenForm() { }
        public void enterCT(Ct i) { }       
    }
    class Ct : IKey
    {
        string ct;
        public Ct(string dB)
        {
            this.ct = dB;
        }
        public string LoadCT(string KeyUser) { return null; }
        public void ExportCT(string NewCT) { }
    }
    class Exam : IExam
    {
        public Exam() { }
        public void ExportTimer(connect db) { }
        public void ExportResult(connect db) { }
        public void sumresult(connect db) { }
        public void LoadDB() { }
        public void View(object Row, object theme) { }
        public void DropTimer() { }

    }
    class Form : INavigation
    {
        string name;
        public Form() { }
        public void OpenForm() { }
        public void CloseForm() { }
        public void PrintTopics(int X, int Y) { }
        public void Row(object Row, object Topics) { }
        public object View(object Row, object theme) { return 0; }

        
    }
    class Animation
    {
        string name;
        public Animation() { }
        public void Play() { }
        public void Stop() { }

    }
    class Key : IKey
    {
        public Key() { }
        public void Keyconn(connect db) { }
        public void LoadForm(Form name) { }
        public string LoadCT(string KeyUser) { return null; }
        public void ExportCT(string NewCT) { }

    }
    class Autor : IAutor
    {
        public Autor() { }
        public void Add(connect table) { }
        public void AddNew(string add) { }

    }
    class teacher : ITeacher
    {
        Statisstic stat;
        public teacher() { }
        public void Print() { }
        public void PrintTopics(string LoadCT) { }
        public void FormGROUP() { }
        public void Stat(object group) { }

    }
    class Statisstic
    {

        public Statisstic() { }
        public void Add() { }
        public void AGV(learner yes) { }
        public void time(DateTime time) { }

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
