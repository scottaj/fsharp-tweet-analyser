open TweetAnalyser.Tweets

[<EntryPoint>]
let main argv =
  System.Console.ForegroundColor <- System.ConsoleColor.Green
  printf "Enter a tweet: "
  let tweet = new Tweet(System.Console.ReadLine())

  System.Console.Clear()
  printfn "you entered: %s" tweet.Text
  printfn "it is %d characters long" tweet.Length

  if not tweet.Valid then
    System.Console.ForegroundColor <- System.ConsoleColor.Red
    printfn "it is over the maximum tweet length of 140 characters"
    System.Console.ForegroundColor <- System.ConsoleColor.Green

  let hastags = tweet.HashTags |> String.concat " "
  printfn "it has %d hastags: %s" tweet.HashTags.Length hastags

  let mentions = tweet.Mentions |> String.concat " "
  printfn "it has %d mentions: %s" tweet.Mentions.Length mentions

  0 // return an integer exit code
