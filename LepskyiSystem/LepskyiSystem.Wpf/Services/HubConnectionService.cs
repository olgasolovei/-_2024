using LepskyiSystem.Dto.AnalyzeCraneDto;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepskyiSystem.Wpf.Services
{
    public class HubConnectionService
    {
        private readonly HubConnection _connection;

        public event Action<AnalyzedCraneDataDto>? AnalyzedCraneDataRecived;

        public HubConnectionService(HubConnection hubConnection)
        {
            _connection = hubConnection;
            _connection.On<AnalyzedCraneDataDto>("CraneDataMessage", ReciveData);

            Connected = false;
        }

        public bool Connected { get; private set; }

        public async Task Connect()
        {
            await _connection.StartAsync();
            Connected = true;
        }

        private void ReciveData(AnalyzedCraneDataDto data)
        {
            AnalyzedCraneDataRecived?.Invoke(data);
        }
    }
}
