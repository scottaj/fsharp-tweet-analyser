namespace TweetAnalyser
module Tweets =
  type Tweet(text:string) =

    let maxLength = 140

    let findTokensThatStartWith (tokens:string[]) (startsWith:string) =
      tokens |> Array.filter (fun word -> word.StartsWith startsWith)

    member val Text = text with get, set

    member this.Length
      with get() = this.Text.Length

    member this.Valid
      with get() = this.Length <= maxLength

    member this.HashTags
      with get() = findTokensThatStartWith this.Tokens "#"

    member this.Mentions
      with get() = findTokensThatStartWith this.Tokens "@"

    member private this.Tokens
      with get() = this.Text.Split ' '
