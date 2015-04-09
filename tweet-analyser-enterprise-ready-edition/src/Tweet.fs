namespace TweetAnalyser
module Tweets =
  type Tweet(text:string) =

    let maxLength = 140

    member val Text = text with get, set

    member this.Length
      with get() = this.Text.Length

    member this.Valid
      with get() = this.Length <= maxLength
