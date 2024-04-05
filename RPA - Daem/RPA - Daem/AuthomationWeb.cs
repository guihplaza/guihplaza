using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPADaem
{
    public class AuthomationWeb
    {
        public IWebDriver driver;
        public AuthomationWeb()
        {
            this.driver = new EdgeDriver();

        }

        public void Runner()
        {
            var random = new Random();         
            var faker = new Faker();         
            var nome = faker.Name.FullName();
            var email = $"{nome.Replace(" ", "")}{random.Next(1000)}@gmail.com";
            var celular = faker.Phone.PhoneNumber();
            var cidade = faker.Address.City();
            var textoAleatorio = faker.Lorem.Sentence();

            driver.Navigate().GoToUrl("https://www.daem.com.br/contato/index");

            var combo = driver.FindElement(By.XPath("//*[@id=\"departamento\"]"));//combo departamento
            var selectElement = new SelectElement(combo);

            selectElement.SelectByIndex(8);

            driver.FindElement(By.XPath("//*[@id=\"nome\"]")).SendKeys(nome);//nome
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys(email);//email
            driver.FindElement(By.XPath("//*[@id=\"cidade\"]")).SendKeys(cidade);//cidade
            driver.FindElement(By.XPath("//*[@id=\"estado\"]")).SendKeys("SP");//Estado
            driver.FindElement(By.XPath("//*[@id=\"telefone\"]")).SendKeys(celular);//telefone
            driver.FindElement(By.XPath("//*[@id=\"msg\"]")).SendKeys(textoAleatorio);//mensagem


            driver.FindElement(By.XPath("//*[@id=\"btnSubmit\"]")).Click(); //botao final de enviar

        }
    }
}
