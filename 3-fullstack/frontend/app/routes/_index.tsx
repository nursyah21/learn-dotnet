import type { Route } from "./+types/_index";

export function meta({}: Route.MetaArgs) {
  return [
    { title: "New React Router " },
    { name: "description", content: "Welcome to React Router!" },
  ];
}



export default function Home() {
  return <>
    <h1>home</h1>
  </>;
}
