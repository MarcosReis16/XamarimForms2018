using System;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string CEP = cep.Text.Trim();
            if (IsValidCEP(CEP))
            {
                try
                {
                    Endereco end = ViaCEP.BuscarEnderecoViaCEP(CEP);
                    if (end != null)
                    {
                        resultado.Text = string.Format("Endereço: {2} de {3},{0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + CEP, "OK");
                    }
                    
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
                

            }
            
        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }

            int novoCEP = 0;
            if(int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! CEP deve conter apenas números!", "OK");
                valido = false;
            }

            return valido;
            
        }
    }
}
