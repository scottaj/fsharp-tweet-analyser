namespace TweetAnalyser
module Tweets =
  type Tweet(text:string) =
    member val Text = text with get, set
