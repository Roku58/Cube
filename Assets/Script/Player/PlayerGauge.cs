using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGauge : MonoBehaviour
{
    [SerializeField] private Image lifeGauge;
    [SerializeField] private Image lifeBackGauge;
    [SerializeField] private Image expGauge;
    [SerializeField] private Image expBackGauge;

    private PlayerState player;
    private TimerText timer;
    private Tween redGaugeTween;

    public void GaugeReduction(float reducationValue, float time = 1f)
    {
        var valueFrom = player.playerLife / player.playerMaxLife;
        var valueTo = (player.playerLife - reducationValue) / player.playerMaxLife;

        // —ÎƒQ[ƒWŒ¸­
        lifeGauge.fillAmount = valueTo;

        if (redGaugeTween != null)
        {
            redGaugeTween.Kill();
        }

        // ÔƒQ[ƒWŒ¸­
        redGaugeTween = DOTween.To(
            () => valueFrom,
            x => {
                lifeBackGauge.fillAmount = x;
            },
            valueTo,
            time
        );
    }

    public void SetPlayer(PlayerState player)
    {
        this.player = player;
    }
}