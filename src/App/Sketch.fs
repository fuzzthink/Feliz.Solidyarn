module Sketch

open Browser.Types
open Feliz.JSX
open Fable.Core
open Fable.Core.JsInterop

module Sketch =
  let setStyle (el: HTMLElement) ((key, value): string * string) =
    el?style?(key) <- value

  let maxGridPixelWidth = 500.

  let randomHexColorString(): string =
    let v = JS.Math.random() * 16777215. |> int
    "#" + System.Convert.ToString(v, 16)

  let clampGridSideLength(newSideLength) =
    min (max newSideLength 0.) 100.

  [<JSX.Component>]
  let App(initialSide: float) =
    let gridSideLength, setGridSideLength = Solid.createSignal(initialSide)
    let gridTemplateString = Solid.createMemo(fun () ->
      $"repeat({gridSideLength()}, {maxGridPixelWidth / gridSideLength()}px)")

    Html.fragment [
      Html.div [
        Attr.style [ Css.marginBottom 10 ]
        Html.children [
          Html.label "Grid Side Length: "
          Html.input [
            Attr.typeNumber
            Attr.value (gridSideLength().ToString())
            Ev.onInput(fun e ->
              (e.currentTarget :?> HTMLInputElement).valueAsNumber
              |> clampGridSideLength
              |> setGridSideLength
            )
          ]
        ]
      ]

      Html.div [
        Attr.style [
          Css.displayGrid
          Css.gridTemplateRows [gridTemplateString() |> grid.ofString]
          Css.gridTemplateColumns [gridTemplateString() |> grid.ofString]
        ]
        Html.children [
          Solid.Index(
            each = (Array.init (gridSideLength() ** 2 |> int) id),
            fallback = (Html.text "Input a grid side length."),
            child = (fun _ _ ->
              Html.div [
                Attr.className "cell"
                Ev.onMouseEnter(fun ev ->
                  let el = ev.currentTarget :?> HTMLElement
                  Css.backgroundColor(randomHexColorString()) |> setStyle el
                  JS.setTimeout (fun () ->
                    Css.backgroundColor "initial" |> setStyle el) 500
                  |> ignore
                )
              ]
            ))
        ]
      ]
    ]