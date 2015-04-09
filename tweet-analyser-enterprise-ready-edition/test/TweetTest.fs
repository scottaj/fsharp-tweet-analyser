namespace TweetAnalyserTests
open NUnit.Framework
open FsUnit
open TweetAnalyser.Tweets

[<TestFixture>]
type ``a simple tweet`` ()=
  let tweet = Tweet("a simple tweet")

  [<Test>]
  member x.``contains the tweet text`` ()=
    tweet.Text |> should equal "a simple tweet"

  [<Test>]
  member x.``contains the tweet length`` ()=
    tweet.Length |> should equal 14

  [<Test>]
  member x.``updates the length when the text changes`` ()=
    tweet.Text <- "new tweet"
    tweet.Length |> should equal 9
