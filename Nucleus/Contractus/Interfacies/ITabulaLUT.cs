namespace Yulinti.Nucleus.Contractus {
    // 0~1の範囲の値を入力として受け取る。出力は0~1の範囲の値となる。
    public interface ITabulaLUT01<T>
    {
        T this[float x] { get; }
    }
    
    // -1~1の範囲の値を入力として受け取る。出力は0~1の範囲の値となる。
    public interface ITabulaLUTSignedTo01<T>
    {
        T this[float x] { get; }
    }
    
    // -1~1の範囲の値を入力として受け取る。出力はラジアンの範囲の値となる。
    // 逆三角関数用。
    public interface ITabulaLUTSignedToRad<T>
    {
        T this[float x] { get; }
    }
}