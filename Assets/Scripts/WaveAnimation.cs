using UnityEngine;
using DG.Tweening;

public class WaveAnimation : MonoBehaviour {

    public float moveDistance = 1f;
    public float refreshSpeed = 0.2f; //lower => faster

    private float turboDistance;
    private float turboRefresh;
	private float myYposition;

    public bool turboMode = false;

    private Tween myTween;
    private GameplayManager mGameplayManager;

    void Start () {
		myYposition = transform.localPosition.y;

        mGameplayManager = FindObjectOfType<GameplayManager>();
        turboDistance = moveDistance;
        turboRefresh = refreshSpeed / 2;
        myTween = transform.DOLocalMoveY(myYposition + moveDistance, refreshSpeed).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }

    void Update()
    {
/*        if (mGameplayManager.smashMode && !turboMode)
        {
            ChangeMode();
        }

        if (!mGameplayManager.smashMode && turboMode)
        {
            ChangeMode();
        }*/
    }

    public void ChangeMode()
    {
        myTween.Rewind();
        if(turboMode)
            myTween = transform.DOLocalMoveY(moveDistance, refreshSpeed).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        else
            myTween = transform.DOLocalMoveY(turboDistance, turboRefresh).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        turboMode = !turboMode;
    }
}
