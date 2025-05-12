using System;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace AppTempoAgoraSQLite
{
    public partial class MainPage : ContentPage
    {
        private PrevisaoService _service;

        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "previsoes.db3");
            _service = new PrevisaoService(dbPath);

            CarregarPrevisoes();
        }

        private async void OnObterPrevisaoClicked(object sender, EventArgs e)
        {
            string cidade = cidadeEntry.Text?.Trim();

            if (string.IsNullOrEmpty(cidade))
            {
                await DisplayAlert("Erro", "Digite uma cidade", "OK");
                return;
            }

            // Simulação de API
            var previsao = new PrevisaoTempo
            {
                Cidade = cidade,
                Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Temperatura = $"{new Random().Next(18, 35)}°C",
                Condicao = "chuva moderada"
            };

            await _service.AdicionarPrevisaoAsync(previsao);
            CarregarPrevisoes();
        }

        private async void CarregarPrevisoes()
        {
            var lista = await _service.ObterPrevisoesAsync();
            previsoesListView.ItemsSource = lista;
        }
    }
}