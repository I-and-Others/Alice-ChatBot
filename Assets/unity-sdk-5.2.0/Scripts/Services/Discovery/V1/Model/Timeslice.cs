/**
* (C) Copyright IBM Corp. 2019, 2021.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBM.Watson.Discovery.V1.Model
{
    /// <summary>
    /// Timeslice.
    /// </summary>
    public class Timeslice : QueryAggregation
    {
        /// <summary>
        /// The field where the aggregation is located in the document.
        /// </summary>
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }
        /// <summary>
        /// Interval of the aggregation. Valid date interval values are second/seconds minute/minutes, hour/hours,
        /// day/days, week/weeks, month/months, and year/years.
        /// </summary>
        [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
        public string Interval { get; set; }
        /// <summary>
        /// Used to indicate that anomaly detection should be performed. Anomaly detection is used to locate unusual
        /// datapoints within a time series.
        /// </summary>
        [JsonProperty("anomaly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Anomaly { get; set; }
    }
}
