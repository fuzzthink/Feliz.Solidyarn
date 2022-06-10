module Counter

open Feliz.JSX
open Fable.Core

[<JSX.Component>]
let Counter () =
  let count, setCount = Solid.createSignal(0)
  let doubled() = count() * 2
  let quadrupled() = doubled() * 2

  Html.fragment [
    Html.p $"{count()} * 2 = {doubled()}"
    Html.p $"{doubled()} * 2 = {quadrupled()}"
    Html.br []
    Html.button [
      Attr.className "button"
      Ev.onClick(fun _ -> count() + 1 |> setCount)
      Html.children [
        Html.text $"Click me!"
      ]
    ]
  ]