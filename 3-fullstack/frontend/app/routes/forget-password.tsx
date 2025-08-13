import { useForm, type SubmitHandler } from "react-hook-form";
import { Link } from "react-router";
import { toast, Toaster } from "sonner";

type InputForgetPassword = {
  email: string;
}

export default function Home() {

  const { handleSubmit, register } = useForm<InputForgetPassword>();
  const onSubmit: SubmitHandler<InputForgetPassword> = (data) => {
    console.log(data)
    toast.error("theres error in here");
  }

  return <>
    <div className="flex h-screen justify-center items-center flex-col">
      <form onSubmit={handleSubmit(onSubmit)} className="w-sm gap-2 flex flex-col bg-gray-200 dark:bg-gray-800 p-8 rounded-2xl mb-2">

        <h1 className="text-2xl mb-2">Forget Password</h1>
        <div>
          <label htmlFor="email">Email</label>
          <input {...register("email")} id="email" type="email" placeholder="hai@mail.com" className="w-full dark:bg-gray-900 dark:text-white rounded-xl" required/>
        </div>

        <button className="mt-2 border p-2 text-white bg-blue-600 hover:opacity-60 rounded-xl border-none">Send</button>

      </form>
    </div>
  </>;
}
