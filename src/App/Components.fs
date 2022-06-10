module Components

open Feliz.JSX
open Fable.Core

[<JSX.Component>]
let Div (classes: string seq) children =
  Html.div [
    Attr.classes classes
    Html.children [
      Html.propsChildren children
    ]
  ]