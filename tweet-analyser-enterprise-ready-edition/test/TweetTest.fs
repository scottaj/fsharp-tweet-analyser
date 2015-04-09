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
    tweet.Valid |> should be False

  [<Test>]
  member x.``is valid again if it is shortened`` ()=
    tweet.Text <- "A valid tweet"
    tweet.Valid |> should be True

[<TestFixture>]
type ``a tweet with #hashtags`` ()=
  let tweet = Tweet("a #tweet with some #hashtags in it")

  [<Test>]
  member x.``has a list of hashtags`` ()=
    tweet.HashTags |> should haveLength 2
    tweet.HashTags |> should contain "#tweet"
    tweet.HashTags |> should contain "#hashtags"

  [<Test>]
  member x.``has an empty #hashtags list if the tweet has no hashtags`` ()=
    tweet.Text <- "no hashtags"
    tweet.HashTags |> should haveLength 0

[<TestFixture>]
type ``a tweet with mentions`` ()=
  let tweet = Tweet("a tweet that mentions @someUser and @someOtherUser")

  [<Test>]
  member x.``has a list of mentions`` ()=
    tweet.Mentions |> should haveLength 2
    tweet.Mentions |> should contain "@someUser"
    tweet.Mentions |> should contain "@someOtherUser"

  [<Test>]
  member x.``has an empty #mentions list if the tweet has no mentions`` ()=
    tweet.Text <- "no mentions"
    tweet.Mentions |> should haveLength 0
