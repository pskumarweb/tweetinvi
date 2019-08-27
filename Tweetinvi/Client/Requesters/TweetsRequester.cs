﻿using System.Threading.Tasks;
using Tweetinvi.Core.Controllers;
using Tweetinvi.Core.Factories;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO;
using Tweetinvi.Parameters;

namespace Tweetinvi.Client.Requesters
{
    public interface IInternalTweetsRequester : ITweetsRequester, IBaseRequester
    {
    }

    /// <summary>
    /// A client providing all the methods related with tweets.
    /// The results from this client contain additional metadata.
    /// </summary>
    public interface ITweetsRequester
    {
        // Tweets
        
        /// <summary>
        /// Get a tweet
        /// </summary>
        /// <returns>TwitterResult containing specified tweet</returns>
        Task<ITwitterResult<ITweetDTO, ITweet>> GetTweet(long tweetId);
        
        /// <summary>
        /// Get multiple tweets
        /// </summary>
        /// <returns>TwitterResult containing multiple tweets</returns>
        Task<ITwitterResult<ITweetDTO[], ITweet[]>> GetTweets(long[] tweetIds);

        /// <summary>
        /// Publish a tweet
        /// </summary>
        /// <returns>TwitterResult containing the published tweet</returns>
        Task<ITwitterResult<ITweetDTO, ITweet>> PublishTweet(string text);
        
        /// <summary>
        /// Publish a tweet
        /// </summary>
        /// <returns>TwitterResult containing the published tweet</returns>
        Task<ITwitterResult<ITweetDTO, ITweet>> PublishTweet(IPublishTweetParameters parameters);

        /// <summary>
        /// Destroying a tweet
        /// </summary>
        /// <returns>TwitterResult with the success status of the request</returns>
        Task<ITwitterResult> DestroyTweet(long tweetId);
        
        /// <summary>
        /// Destroying a tweet
        /// </summary>
        /// <returns>TwitterResult with the success status of the request</returns>
        Task<ITwitterResult> DestroyTweet(ITweetDTO tweet);

        // Retweets
        
        /// <summary>
        /// Get the retweets associated with a specific tweet
        /// </summary>
        /// <returns>TwitterResult containing the retweets</returns>
        Task<ITwitterResult<ITweetDTO[], ITweet[]>> GetRetweets(ITweetIdentifier tweet, int? maxRetweetsToRetrieve);

        /// <summary>
        /// Publish a retweet 
        /// </summary>
        /// <returns>TwitterResult containing the published retweet</returns>
        Task<ITwitterResult<ITweetDTO, ITweet>> PublishRetweet(ITweetIdentifier tweet);
        
        /// <summary>
        /// Destroy a retweet
        /// </summary>
        /// <returns>TwitterResult containing the success status of the request</returns>
        Task<ITwitterResult> DestroyRetweet(ITweetIdentifier retweetId);
    }
    
    public class TweetsRequester : BaseRequester, IInternalTweetsRequester
    {
        private readonly ITweetFactory _tweetFactory;
        private readonly ITweetController _tweetController;

        public TweetsRequester(
            ITweetFactory tweetFactory,
            ITweetController tweetController)
        {
            _tweetFactory = tweetFactory;
            _tweetController = tweetController;
        }

        // Tweets
        public Task<ITwitterResult<ITweetDTO, ITweet>> GetTweet(long tweetId)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetFactory.GetTweet(tweetId, request), request);
        }

        public Task<ITwitterResult<ITweetDTO[], ITweet[]>> GetTweets(long[] tweetIds)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetFactory.GetTweets(tweetIds, request), request);
        }

        // Tweets - Publish
        public Task<ITwitterResult<ITweetDTO, ITweet>> PublishTweet(string text)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.PublishTweet(text, request), request);
        }

        public Task<ITwitterResult<ITweetDTO, ITweet>> PublishTweet(IPublishTweetParameters parameters)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.PublishTweet(parameters, request), request);
        }

        // Tweets - Destroy
        public Task<ITwitterResult> DestroyTweet(long tweetId)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.DestroyTweet(tweetId, request), request);
        }

        public Task<ITwitterResult> DestroyTweet(ITweetDTO tweet)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.DestroyTweet(tweet, request), request);
        }

        // Retweets
        public Task<ITwitterResult<ITweetDTO[], ITweet[]>> GetRetweets(ITweetIdentifier tweet, int? maxRetweetsToRetrieve)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.GetRetweets(tweet, maxRetweetsToRetrieve, request), request);
        }

        // Retweets - Publish
        public Task<ITwitterResult<ITweetDTO, ITweet>> PublishRetweet(ITweetIdentifier tweet)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.PublishRetweet(tweet, request), request);
        }

        // Retweets - Destroy
        public Task<ITwitterResult> DestroyRetweet(ITweetIdentifier retweetId)
        {
            var request = _twitterClient.CreateRequest();
            return ExecuteRequest(() => _tweetController.DestroyRetweet(retweetId, request), request);
        }

        // Factories
    }
}
