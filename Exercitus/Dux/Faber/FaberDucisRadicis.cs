// 注意　ここで初期化する奴はDontDestroyOnLoadになるぞ。貴公、気をつけることだな。

using VContainer;
using VContainer.Unity;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    public static class FaberDucisRadicis {
        public static void Initio(IContainerBuilder builder) {
            builder.Register<LegatusConfirmationis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<LegatusMonitionis>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<IDuxExercitusRadicis, DuxExercitusRadicis>(Lifetime.Singleton);
        }
    }
}
