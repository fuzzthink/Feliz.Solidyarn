module App

open Browser
open Browser.Types
open Feliz.JSX
open Fable.Core
open Components

// Entry point must be in a separate file
// for Vite Hot Reload to work

[<RequireQualifiedAccess>]
type Tab =
    | Counter
    | Styles
    | Sketch
    | TodoElmish
    | TodoNonElmish
    | Shoelace
    member this.Name =
        match this with
        | Counter -> "Counter"
        | Styles -> "Styles"
        | Sketch -> "Sketch"
        | TodoElmish -> "Todo Elmish"
        | TodoNonElmish -> "Todo Non-Elmish"
        | Shoelace -> "Shoelace Web Components"

[<JSX.Component>]
let TabEl(tab: Tab, activeTab, setActiveTab) =
    Html.li [
        Attr.classList ["is-active", tab = activeTab()]
        Html.children [
            Html.a [
                Ev.onClick (fun _ -> tab |> setActiveTab)
                Html.children [
                    Html.text tab.Name
                ]
            ]
        ]
    ]

[<JSX.Component>]
let Tabs() =
    let activeTab, setActiveTab = Solid.createSignal(Tab.Sketch)
    Html.fragment [
        Html.div [
            Attr.className "tabs"
            Attr.style [
                Css.marginBottom (length.rem 0.5)
            ]
            Html.children [
                Html.ul [
                    Html.children [
                        TabEl(Tab.Counter, activeTab, setActiveTab)
                        TabEl(Tab.Styles, activeTab, setActiveTab)
                        TabEl(Tab.Sketch, activeTab, setActiveTab)
                        TabEl(Tab.TodoElmish, activeTab, setActiveTab)
                        TabEl(Tab.TodoNonElmish, activeTab, setActiveTab)
                        TabEl(Tab.Shoelace, activeTab, setActiveTab)
                    ]
                ]
            ]
        ]
        Html.div [
            Attr.style [
                Css.margin (length.zero, length.auto)
                Css.maxWidth 800
                Css.padding 20
            ]
            Html.children [
                Solid.Switch([
                    Solid.Match(activeTab() = Tab.Counter, Counter())
                    Solid.Match(activeTab() = Tab.Styles, Styles())
                    Solid.Match(activeTab() = Tab.Sketch, Sketch.App(10.))
                    Solid.Match(activeTab() = Tab.TodoElmish, TodoElmish.App())
                    Solid.Match(activeTab() = Tab.TodoNonElmish, TodoNonElmish.App())
                    Solid.Match(activeTab() = Tab.Shoelace, Shoelace.ImageComparer())
                ])
            ]
        ]
    ]

Solid.render(Tabs, document.getElementById("app-container"))
