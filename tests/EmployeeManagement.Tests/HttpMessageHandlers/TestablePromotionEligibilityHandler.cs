using EmployeeManagement.Api.Business;
using System.Text.Json;
using System.Text;

namespace EmployeeManagement.Tests.HttpMessageHandlers;

public class TestablePromotionEligibilityHandler : HttpMessageHandler
{
    private readonly bool _isEligibleForPromotion;

    public TestablePromotionEligibilityHandler(bool isEligibleForPromotion)
    {
        _isEligibleForPromotion = isEligibleForPromotion;
    }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var promotionEligibility = new PromotionEligibility()
        {
            EligibleForPromotion = _isEligibleForPromotion
        };

        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(
                   JsonSerializer.Serialize(promotionEligibility,
                   new JsonSerializerOptions
                   {
                       PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                   }),
                   Encoding.ASCII,
                   "application/json")
        };


        return Task.FromResult(response);
    }
}
