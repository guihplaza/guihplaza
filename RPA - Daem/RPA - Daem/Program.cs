using RPADaem;

var web = new AuthomationWeb();

// Loop infinito para execução contínua
while (true)
{
    // Aqui você pode colocar o código que deseja executar repetidamente
    web.Runner();

    // Espera de 0.1 segundo antes da próxima iteração
    Thread.Sleep(1);
}