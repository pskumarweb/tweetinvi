﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using Newtonsoft.Json.Linq;
using Tweetinvi.Core.Models;
using Tweetinvi.Core.Web;
using Tweetinvi.Models.DTO.QueryDTO;

namespace Testinvi.SetupHelpers
{
    [ExcludeFromCodeCoverage]
    public static class TwitterAccessorHelper
    {
        public static void ArrangeExecuteGETQuery(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            JObject result)
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecuteGETQuery(query))
                .Returns(result);
        }

        public static void ArrangeExecuteGETQuery<T>(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            T result) where T : class
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecuteGETQuery<T>(query, null))
                .Returns(result);
        }

        public static void ArrangeExecutePOSTQuery<T>(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            T result) where T : class
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecutePOSTQuery<T>(query, null))
                .Returns(result);
        }

        public static void ArrangeExecutePOSTQuery(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            JObject result)
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecutePOSTQuery(query))
                .Returns(result);
        }

        public static void ArrangeExecutePOSTMultipartQuery<T>(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            T result) where T : class
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecuteMultipartQuery<T>(A<IMultipartHttpRequestParameters>.That.Matches(y => y.Url == query), null))
                .Returns(result);
        }

        public static void ArrangeTryExecutePOSTQuery(
           this Fake<ITwitterAccessor> fakeTwitterAccessor,
           string query,
           bool result)
        {
            fakeTwitterAccessor
                .CallsTo(x => x.TryExecutePOSTQuery(query, null))
                .ReturnsLazily(() =>
                {
                    return result;
                });

            fakeTwitterAccessor
                .CallsTo(x => x.TryExecutePOSTQuery(query))
                .ReturnsLazily(() =>
                {
                    var asyncOperation = A.Fake<AsyncOperation<string>>();
                    asyncOperation.Success = result;

                    return asyncOperation;
                });
        }

        public static void ArrangeTryExecuteDELETEQuery(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            bool result)
        {
            fakeTwitterAccessor
                .CallsTo(x => x.TryExecuteDELETEQuery(query, null))
                .ReturnsLazily(() =>
                {
                    return result;
                });

            fakeTwitterAccessor
                .CallsTo(x => x.TryExecuteDELETEQuery(query))
                .ReturnsLazily(() =>
                {
                    var asyncOperation = A.Fake<AsyncOperation<string>>();
                    asyncOperation.Success = result;

                    return asyncOperation;
                });
        }

        public static void ArrangeExecuteCursorGETQuery<T, T1>(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            IEnumerable<T> result) where T1 : class, IBaseCursorQueryDTO<T>
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecuteCursorGETQuery<T, T1>(query, A<int>.Ignored, null))
                .Returns(result);
        }

        // Json
        public static void ArrangeExecuteJsonGETQuery(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            string jsonResult)
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecuteGETQueryReturningJson(query))
                .Returns(jsonResult);
        }

        public static void ArrangeExecuteJsonPOSTQuery(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            string jsonResult)
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecutePOSTQueryReturningJson(query))
                .Returns(jsonResult);
        }

        public static void ArrangeExecuteJsonCursorGETQuery<T>(
            this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query,
            IEnumerable<string> jsonResult) where T : class, IBaseCursorQueryDTO
        {
            fakeTwitterAccessor
                .CallsTo(x => x.ExecuteJsonCursorGETQuery<T>(query, A<int>.Ignored, A<string>.Ignored))
                .Returns(jsonResult);
        }

        // POST JSON body & get JSON response
        public static void ArrangeExecutePostQueryJsonBody<T>(this Fake<ITwitterAccessor> fakeTwitterAccessor,
            string query, object reqBody, T result) where T : class
        {
            fakeTwitterAccessor.CallsTo(x => x.ExecutePOSTQueryJsonBody<T>(query, reqBody, null)).Returns(result);
        }
    }
}