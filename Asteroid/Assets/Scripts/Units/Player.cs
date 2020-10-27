using UnityEngine;

public class Player : HealthUnit {
    private const int CollissionPlayerDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("We collide with " + collision.name);
        this.TakeDamage(CollissionPlayerDamage);
    }

    protected override void Die() {
        base.Die();

        //Add GameOver here
        //Should remove object (?)

        Destroy(gameObject, .5f);
    }

    //TODO: Вынести в отдельный классс?
    public void GameOver() {
        //Вывести UI
        //Сохранить HighScore
    }
}
