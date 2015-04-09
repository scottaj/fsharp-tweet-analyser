namespace TweetAnalyser
module Tweets =
  type Tweet(text:string) =
    member val Text = text with get, set
    member this.Length
      with get () = this.Text.Length
