namespace TweetAnalyser
open NUnit.Framework
open FsUnit
open Tweets

[<TestFixture>]
type ``a simple tweet`` ()=
  let tweet = Tweet("a simple tweet")

  [<Test>]
  member x.``contains the tweet text`` ()=
    tweet.Text |> should equal "a simple tweet"
