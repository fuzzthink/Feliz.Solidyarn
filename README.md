# Feliz.Solidyarn

## Feliz.Solid Info

This is an early prototype to compile F# to JSX in order to use a [Feliz-like](https://zaid-ajaj.github.io/Feliz/) HTML API with [SolidJS](https://www.solidjs.com/).

## Fork Info
- Use zero-install yarn
- Break up `Components.fs` into separate component files.
- Indent with 2 spaces
- Use of `Match` instead of `Solid.Match`

## Notes

- JSX elements need to be **solved at compile time** so it's not possible to use list generators for HTML attributes or children.

- Requires Fable 4 Snake Island (currently in alpha)

## Usage

Yarn zero-install, no setup needed. If error, install yarn per https://yarnpkg.com/getting-started/install and run `yarn add`.

`yarn init -2` (per instruction) will overwrites package.json, so make a copy of it first if need to do this.

```cs
yarn start // To watch & run
yarn add pkg-name // -D for dev only dep
yarn remove pkg-name
```