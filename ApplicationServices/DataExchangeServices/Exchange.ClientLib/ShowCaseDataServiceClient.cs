using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;

namespace Exchange.ClientLib
{
    public class ShowCaseDataServiceClient
    {
        private string _dataServiceUrlBase;

        public void DocketCodes(string partialDocketCode)
        {
            Uri uri = new Uri(_dataServiceUrlBase + "/DocketCodeService.svc/");
            DataServiceContext context = new DataServiceContext(uri);

            StringBuilder cmdBuilder = new StringBuilder();
            cmdBuilder.AppendFormat("DocketCodes?$filter=substringof('{0}',DocketDescription)", partialDocketCode);

            IEnumerable<DocketCode> dcQuery =
                                context.Execute<ClientDataModel.DocketCodeModel.DocketCode>(new Uri(strCmd, UriKind.Relative));
            List<ClientDataModel.DocketCodeModel.DocketCode> dcs = dcQuery.ToList<ClientDataModel.DocketCodeModel.DocketCode>();

        }
    }
}
