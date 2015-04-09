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

[<TestFixture>]
type ``a tweet that is too long`` ()=
  let tweet = Tweet("A tweet that is very long and contains a large number of different words describing different thing in very long ways that are probably not that interesting anyways")

  [<Test>]
  member x.``is marked as invalid`` ()=
    tweet.Valid |> should equal false

  [<Test>]
  member x.``is valid again if it is shortened`` ()=
    tweet.Text <- "A valid tweet"
    tweet.Valid |> should equal true
