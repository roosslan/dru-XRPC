using System;
using MolineSoftware.DrupalXmlRpc;

namespace trade {
    public class DrupalService : DrupalXmlRpcService<IDrupalXmlRpc> {
        #region | Constructors |
        /// <summary>
        /// Intialize a new instance of <see cref="DrupalService"/>
        /// </summary>
        public DrupalService()
            : base()
        {
        }

        /// <summary>
        /// Intialize a new instance of <see cref="DrupalService"/>
        /// This information can be obtained from your Drupal Site.
        /// </summary>
        /// <param name="key">The Service Key</param>
        /// <param name="domain">The Service Domain</param>
        /// <param name="serviceurl">The Service URL</param>
        public DrupalService(string key, string domain, string serviceurl)
            : this()
        {
            base.ServiceKey = key;
            base.ServiceURL = serviceurl;
            base.ServiceDomain = domain;
        }
        #endregion

        #region | Public Properties |
        /// <summary>
        /// Gets the current Unix time stamp.
        /// </summary>
        /// <returns></returns>
        public static new string GetUnixTimestamp()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return Convert.ToString(Convert.ToUInt64(ts.TotalSeconds));
        }
        #endregion

    }

}
