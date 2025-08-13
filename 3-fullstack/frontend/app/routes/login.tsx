import { useForm, type SubmitHandler } from "react-hook-form";

type InputLogin = {
  email: string;
  password: string;
}

export default function Home() {

  const { handleSubmit, register } = useForm<InputLogin>();
  const onSubmit: SubmitHandler<InputLogin> = (data) => {
    console.log(data)
  }

  return <>
    <div className="flex h-screen justify-center items-center flex-col">
      <form onSubmit={handleSubmit(onSubmit)} className="gap-2 flex flex-col bg-gray-800 p-8 rounded-2xl mb-2">

        <h1 className="text-2xl mb-2">Login</h1>
        <div>
          <label htmlFor="email">Email</label>
          <input {...register("email")} id="email" type="email" placeholder="hai@mail.com" className="w-full dark:bg-gray-900 dark:text-white rounded-xl" />
        </div>

        <div>
          <label htmlFor="password">Password</label>
          <input {...register("password")} type="password" placeholder="password" className="w-full dark:bg-gray-900 dark:text-white rounded-xl" autoComplete="current-password" />
        </div>

        <a href="/forget-password" className="text-xs">Forget Password?</a>

        <button className="mt-2 border p-2 bg-blue-600 hover:opacity-60 rounded-xl border-none">Submit</button>


      </form>
        <a href="/register" className="mt-2 text-sm text-center">Create New Account</a>
    </div>
  </>;
}
