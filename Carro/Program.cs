
var carro = new Carro(new Motor1000(), 100);
Console.WriteLine($"Novo carro criado com Motor {carro.Motor.Nome}");
Console.WriteLine($"Checando gasolina: {carro.Gasolina}%");
Console.WriteLine("Acelerando carro...");
carro.Acelerar();
Console.WriteLine($"Checando gasolina: {carro.Gasolina}%");



interface IMotor
{
    public string Nome { get; }
    public int PontosGasolinaPorKmRodado { get; }
}

class Motor1000 : IMotor
{
    public string Nome => "1000";
    public int PontosGasolinaPorKmRodado => 2;
}

class Motor13 : IMotor
{
    public string Nome => "13";
    public int PontosGasolinaPorKmRodado => 3;
}

class Motor16 : IMotor
{
    public string Nome => "16";
    public int PontosGasolinaPorKmRodado => 5;
}

class Motor20 : IMotor
{
    public string Nome => "20";
    public int PontosGasolinaPorKmRodado => 10;
}

class Carro
{
    public IMotor Motor { get; private set; }
    public int Gasolina { get; private set; }
    public Carro(IMotor motor, int qtdGasolina)
    {
        ValidarQtdGasolina(qtdGasolina);
        Gasolina = qtdGasolina;
        Motor = motor;
    }

    private void ValidarQtdGasolina(int pontosGasolina)
    {
        if (pontosGasolina is < 0 || pontosGasolina is > 100)
            throw new Exception("Quantidade de gasolina inválida");
    }

    public void Acelerar()
    {
        if (Gasolina == 0)
            throw new Exception("Sem gasolina para acelerar");

        Gasolina -= Motor.PontosGasolinaPorKmRodado;
    }
}