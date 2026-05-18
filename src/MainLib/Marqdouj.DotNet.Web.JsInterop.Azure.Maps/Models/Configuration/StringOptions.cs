namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// A list of options to be applied.
    /// </summary>
    public class StringOptions : List<string>, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        public StringOptions()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"><inheritdoc/></param>
        public StringOptions(IEnumerable<string> values)
        {
            AddRange(values);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new StringOptions(this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(",", this);
        }
    }
}
