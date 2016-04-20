namespace AirNavSystem
{
    interface IParametrsStorage
    {
        AlgorithmParams[] LoadParams();
        void StoreParams(params AlgorithmParams[] algorithmParams);
    }
}