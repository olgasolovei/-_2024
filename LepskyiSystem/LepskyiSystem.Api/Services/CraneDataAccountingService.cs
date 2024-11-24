using LepskyiSystem.Api.Hubs;
using LepskyiSystem.Dto.AnalyzeCraneDto;
using Microsoft.AspNetCore.SignalR;

namespace LepskyiSystem.Api.Services
{
    public class CraneDataAccountingService
    {
        private readonly IHubContext<CraneDataHub> _hubContext;
        private readonly List<AnalyzedCraneDataDto> _dataList;
        private long messageCounter;

        public CraneDataAccountingService(IHubContext<CraneDataHub> hubContext)
        {
            _hubContext = hubContext;

            _dataList = new List<AnalyzedCraneDataDto>();
            messageCounter = 1;
        }

        public event Action<AnalyzedCraneDataDto>? DataAdded;

        public void AddData(AnalyzedCraneDataDto data)
        {
            data.MessageId = messageCounter++;
            _dataList.Add(data);

            OnDataAdded(data);
            DataAdded?.Invoke(data);
        }

        private void OnDataAdded(AnalyzedCraneDataDto craneData)
        {
            Console.WriteLine($"Sent message: {craneData.MessageId}");
            _hubContext.Clients.All.SendAsync("CraneDataMessage", craneData);
        }
    }
}
