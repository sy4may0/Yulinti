namespace Yulinti.Exercitus.Dux {
    internal interface IExecutorCivis {
        void Initare(int idCivis);
        void Primum(int idCivis);
        void Confirmare(int idCivis);
        void Purgare(int idCivis);
    }
}