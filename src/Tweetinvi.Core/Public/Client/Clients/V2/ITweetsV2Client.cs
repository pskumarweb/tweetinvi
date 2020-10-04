using System.Threading.Tasks;
using Tweetinvi.Models.V2;
using Tweetinvi.Parameters.V2;

namespace Tweetinvi.Client.V2
{
    public interface ITweetsV2Client
    {
        /// <inheritdoc cref="GetTweetAsync(IGetTweetV2Parameters)"/>
        Task<TweetV2Response> GetTweetAsync(long tweetId);

        /// <summary>
        /// Get a tweet
        /// <para>Read more : https://developer.twitter.com/en/docs/twitter-api/tweets/lookup/api-reference/get-tweets-id </para>
        /// </summary>
        /// <returns>The tweet</returns>
        Task<TweetV2Response> GetTweetAsync(IGetTweetV2Parameters parameters);

        /// <inheritdoc cref="GetTweetsAsync(IGetTweetsV2Parameters)"/>
        Task<TweetsV2Response> GetTweetsAsync(long[] tweetIds);

        /// <summary>
        /// Get multiple tweets
        /// <para>Read more : https://developer.twitter.com/en/docs/twitter-api/tweets/lookup/api-reference/get-tweets </para>
        /// </summary>
        /// <returns>Requested tweets</returns>
        Task<TweetsV2Response> GetTweetsAsync(IGetTweetsV2Parameters parameters);

        /// <inheritdoc cref="ChangeTweetReplyVisibilityAsync(IChangeTweetReplyVisibilityV2Parameters)"/>
        Task<TweetHideV2Response> ChangeTweetReplyVisibilityAsync(long tweetId, TweetReplyVisibility visibility);

        /// <summary>
        /// Set the visibility of a reply tweet
        /// <para>Read more : https://developer.twitter.com/en/docs/twitter-api/tweets/hide-replies/api-reference/put-tweets-id-hidden </para>
        /// </summary>
        /// <returns>The new visibility of the tweet</returns>
        Task<TweetHideV2Response> ChangeTweetReplyVisibilityAsync(IChangeTweetReplyVisibilityV2Parameters parameters);
    }
}